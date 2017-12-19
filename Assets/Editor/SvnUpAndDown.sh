#!/bin/sh
path=${1}
downPath==${2}

echo Svn UP and Down Log here!
echo "upload ab path:"${path}
echo "download ab path:"${downPath}

#下载到要上传的目录
svn checkout svn://localhost/SvnServerAssetBundle --username=hyz --password=123456 ${path}
cd ${path}
#更新
svn update
#添加所有
svn add . --no-ignore --force
#提交
svn commit -m "upload ab to svn server"

echo "upload succ"

#下载到要下载的目录
svn checkout svn://localhost/SvnServerAssetBundle --username=hyz --password=123456 ${downPath}
cd ${downPath}
#更新
svn update

echo "download succ"