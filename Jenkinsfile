stage('Publish') {
  steps {
    script {
      // odredi OS folder
      def osFolder
      if (isUnix()) {
        def uname = sh(script: 'uname', returnStdout: true).trim()
        osFolder = (uname == 'Darwin') ? 'Mac' : 'Linux'
      } else {
        osFolder = 'Win'
      }

      // baza Builds foldera (Desktop)
      def base = isUnix()
        ? "${env.HOME}/Desktop/Builds"
        : "${env.USERPROFILE}\\Desktop\\Builds"

      // final output folder
      def outDir = isUnix()
        ? "${base}/${osFolder}"
        : "${base}\\${osFolder}"

      echo "Publishing to: ${outDir}"

      if (isUnix()) {
        sh "dotnet publish \"Machine Learning.slnx\" -c Release -o \"${outDir}\""
      } else {
        bat "dotnet publish \"Machine Learning.slnx\" -c Release -o \"${outDir}\""
      }
    }
  }
}
