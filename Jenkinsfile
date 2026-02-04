pipeline {
  agent any

  triggers { pollSCM('*/1 * * * *') }

  stages {
    stage('Restore') {
      steps {
        echo 'Restoring...'
        bat 'dotnet --info'
        bat 'dotnet restore "Machine Learning.sln"'
      }
    }

    stage('Build') {
      steps {
        echo 'Building...'
        bat 'dotnet build "Machine Learning.sln" -c Release --no-restore'
      }
    }

    stage('Test') {
      steps {
        echo 'Testing...'
        bat 'dotnet test "Machine Learning.sln" -c Release --no-build'
      }
    }
  }
}