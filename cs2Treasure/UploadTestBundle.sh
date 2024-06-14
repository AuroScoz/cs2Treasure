#!/bin/bash

echo $1
if [ "$1" != "" ]
then
	sh ./UploadBundle.sh aurafortest aurafortest_bundle_test $1
fi