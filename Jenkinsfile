pipeline {
  agent any

  options {
    skipDefaultCheckout(true)
  }

  stages {
    stage('Checkout') {
      steps {
        deleteDir()
        checkout scm
      }
    }

    stage('Publish (Windows)') {
      steps {
        script {
          bat 'dotnet run --project BuildTool -c Release'
        }
      }
    }
  }
}
