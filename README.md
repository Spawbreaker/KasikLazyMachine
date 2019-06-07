# The KasikLazyMachine
A minimal C#/.net application to keep [ArcDPS](https://www.deltaconnected.com/arcdps/), a Guild Wars 2 Addon, easily updated. It's as simple as download and execute.

This program is directed to users who want a quick-and-easy solution to installing and updating ArcDPS. 

## Installation 
Download the binaries from the [Releases](https://github.com/Spawbreaker/KasikLazyMachine/releases), extract into a single folder. 

### Configuration
By default, the application will try to download to C:\Program Files\Guild Wars 2\bin64\
In case you moved your installation directory you'll have to tamper with the KasikLazyMachine.exe.config
Open the file with a text editor and scroll down until you find the line: 
```xml
<add key="gw2dir" value="C:\Program Files\Guild Wars 2\bin64\" />
```
Edit the value to wherever your \bin64 folder is, such as the following example.
```xml
<add key="gw2dir" value="D:\Games\Guild Wars 2\bin64\" />
```

## Usage
Make sure all the files are in the same folder and just run KasikLazyMachine.exe, this will open a command prompt. If there are no errors the program should shortly announce ArcDPS has been updated.
If you encounter any errors feel free to submit an issue here, or PM me (Or send me an ingame mail) to Bruno.8937

## License

This project is licensed under the [MIT License](https://github.com/Spawbreaker/KasikLazyMachine/blob/master/LICENSE)
