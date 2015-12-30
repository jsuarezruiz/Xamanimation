param($installPath, $toolsPath, $package, $project)

  # NOTE: the design assemblies must be in a \Design folder within \lib. 
  # But if we do that, the IDEs will add a reference to it (supposedly 
  # to be fixed in VS2015 Update 1, but we need to make it backwards 
  # compatible). Therefore, we just copy the assemblies from within 
  # an init.ps1 (so that it's done after install, every time a user 
  # opens up the project, since it can be the product of a restore, 
  # rather than install) to the Design folder.
  
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\portable-win+net45+wp80+win81+wpa81+MonoAndroid10+MonoTouch10+Xamarin.iOS10\Design\"
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\MonoAndroid10\Design\"
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\Xamarin.iOS10\Design\"
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\MonoTouch10\Design\"
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\WP80\Design\"
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\wpa81\Design\"
  xcopy /D /Y "$toolsPath\*.Design.dll" "$installPath\lib\win81\Design\"