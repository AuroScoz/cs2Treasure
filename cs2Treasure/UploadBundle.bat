chcp 65001
REM googleProjectID, storagePath, Application.version
echo '開始執行UploadBundle.bat 傳入參數為：' %1 %2 %3
if not "%1" == "" (
	if not "%2" == "" (
		if not "%3" == "" (
			gcloud config set project %1
			gsutil -m cp -r ServerData/%3/* gs://%2/%3/
			gsutil -m setmeta -h "Cache-Control:no-store" -r gs://%2/%3/
			REM gsutil setmeta -h "Cache-Control:no-store" gs://%2/%3/Android/catalog_%3.hash
			REM gsutil setmeta -h "Cache-Control:no-store" gs://%2/%3/Android/catalog_%3.json
			REM gsutil setmeta -h "Cache-Control:no-store" gs://%2/%3/iOS/catalog_%3.hash
			REM gsutil setmeta -h "Cache-Control:no-store" gs://%2/%3/iOS/catalog_%3.json
			pause
			exit 0
		)
	)
)
echo 'Error: parameter contain empty.'
pause
exit -1
