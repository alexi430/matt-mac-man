pipeline {
   agent any
   stages {
      stage('Stage 1'){
         steps {
            echo 'Hello World 1'
         }
      }
      stage('Stage 2'){
         steps {
            echo 'Hello World 2'
         }
      }
      stage('checkout'){
         steps {
            echo 'checkout from git'
            git credentialsId: 'alexi430', url: 'git@github.com:alexi430/matt-mac-man.git'
         }
      }
      stage('edittest'){
         steps {
            echo 'test'
            bat 't.bat'
            nunit testResultsPattern: 'result.xml'
         }
      }
      stage('build'){
         steps {
            echo 'build'
            bat 'u.bat'
         }
      }
   }
}