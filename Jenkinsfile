pipeline {
  agent any

  triggers {
    pollSCM('*/1 * * * *')
  }

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
          if (isUnix()) {
            error("Ovaj job je trenutno podešen samo za Windows (bat).")
          }

          def outDir = "${env.USERPROFILE}\\Desktop\\Builds\\Win"

          bat "if not exist \"${outDir}\" mkdir \"${outDir}\""
          bat "dotnet --info"
          bat "dotnet publish \"Machine Learning.slnx\" -c Release -o \"${outDir}\""
          bat "dir \"${outDir}\""
        }
      }
    }
  }
}
