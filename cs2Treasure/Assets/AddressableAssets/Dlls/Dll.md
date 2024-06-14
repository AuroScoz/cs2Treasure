# Dll 說明

包檔時Dll會包到Dlls/Dlls底下, 子Dlls資料夾不會進入版控, 但父層會進入版控因為要設定Addressables的Label。請注意以下事項：

1. **不要更資料夾名稱：** 請不要隨意更動這裡的資料夾名稱，因為非熱更的程式會抓這裡的Dll(Game.dll.bytes)檔案。
