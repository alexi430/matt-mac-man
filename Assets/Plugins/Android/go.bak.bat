@echo off
adb shell am start -a com.addcomponent.unitynativeplugin.do -n com.addcomponent.unitynativeplugin/com.addcomponent.unitynativeplugin.Example --es "KEY" "alexi123" -t "text/plain"

::adb shell am force-stop com.addcomponent.unitynativeplugin

::adb shell am start -a com.addcomponent.unitynativeplugin.do -n com.addcomponent.unitynativeplugin/com.addcomponent.unitynativeplugin.Example

::adb shell am broadcast -a android.intent.action.MAIN -n com.addcomponent.unitynativeplugin/com.addcomponent.unitynativeplugin.Example
::adb shell am start -n com.addcomponent.unitynativeplugin/com.addcomponent.unitynativeplugin.Example
::adb shell "am broadcast -a com.addcomponent.unitynativeplugin.do -e notify '"'{"debug": false, "title": "Application update!"}'"'"

::adb shell "am broadcast -a com.addcomponent.unitynativeplugin.do -n com.addcomponent.unitynativeplugin/.IntentReceiver
::adb shell "am broadcast -a android.intent.category.HOME -n com.addcomponent.unitynativeplugin/.IntentReceiver -e notify '"'{"debug": false, "title": "Application update!"}'"'"