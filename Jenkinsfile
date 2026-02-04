pipeline {
  agent any
  options{
    skipDefaultcheckout(true)
  }

  triggers { pollSCM('*/1 * * * *') }

  stages {
    stage('Checkout'){
      steps{
        deleteDir()
        checkout scm
      }
    }

    stage('Restore') {
      steps {
        echo 'Restoring...'
        bat 'dotnet --info'
        bat 'dotnet restore "Machine Learning.slnx"'
      }
    }

    stage('Build') {
      steps {
        echo 'Building...'
        bat 'dotnet build "Machine Learning.slnx" -c Release --no-restore'
      }
    }
  }
}