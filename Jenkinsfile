pipeline {
   agent any
   stage('Stage 1'){
       echo 'Hello World 1'
   }
   stage('Stage 2'){
       echo 'Hello World 2'
   }
   stage('checkout'){
       echo 'checkout from git'
       git credentialsId: 'alexi430', url: 'git@github.com:alexi430/matt-mac-man.git'
   }
   stage('edittest'){
       echo 'test'
       bat 't.bat'
       nunit testResultsPattern: 'result.xml'
   }
   stage('build'){
       echo 'build'
       bat 'u.bat'
   }
}