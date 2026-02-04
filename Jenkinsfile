pipeline {
  agent any

  triggers { pollSCM('*/1 * * * *') }

  stages {
    stage('Prepare Workspace'){
      steps{
        deleteDir()
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

    stage('Test') {
      steps {
        echo 'Testing...'
        bat 'dotnet test "Machine Learning.slnx" -c Release --no-build'
      }
    }
  }
}