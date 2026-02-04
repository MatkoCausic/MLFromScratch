pipeline {
  agent any

    triggers{
        pollSCM '*/1 * * * *'
    }
  stages {
    stage('Build') {
      steps {
        echo 'Hello from Build stage'
        bat 'echo Hello from Build (bat)'
      }
    }

    stage('Test') {
      steps {
        echo 'Hello from Test stage'
        bat 'echo Hello from Test (bat)'
      }
    }

    stage('Deliver') {
      steps {
        echo 'Hello from Deliver stage'
        bat 'echo Hello from Deliver (bat)'
      }
    }
  }
}