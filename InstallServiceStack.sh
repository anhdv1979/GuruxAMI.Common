#mono nuget.exe update -self
#If Mnuget is not installed
if [ -e 'nuget.exe' ]; then
echo "Nuget is installed."
else
#Get nuget
wget http://www.nuget.org/nuget.exe
fi

mono nuget.exe update -self
#If nuget exists but nuget.org is not trusted.
if [ "$?" = "1" ]; then
sudo mozroots --import --machine --sync
sudo certmgr --ssl -m https://go.microsoft.com
sudo certmgr --ssl -m https://nugetgallery.blob.core.windows.net
sudo certmgr --ssl -m http://nuget.org
fi

cd packages || mkdir packages || exit 1
mono ../nuget.exe install ServiceStack.Text -Version 3.9.71.0
mono ../nuget.exe install ServiceStack.Common -Version 3.9.71.0
mono ../nuget.exe install ServiceStack -Version 3.9.71.0
mono ../nuget.exe install ServiceStack.OrmLite.SqlServer -Version 3.9.71.0
mono ../nuget.exe install ServiceStack.OrmLite.MySql -Version 3.9.71.0
mono ../nuget.exe install MySql.Data -Version 6.6.4.0
mono ../nuget.exe install Quartz -Version 2.2.3