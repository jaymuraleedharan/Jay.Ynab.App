## Update YNAB Developer Token

1. Get your YNAB token by following the instructions here: https://api.ynab.com/
2. Go to your YNAB App Folder and locate `appsettings.secrets.json` file. If it doesn't exist, create a new file with that name.
3. Replace `YOUR_YNAB_TOKEN_HERE` with your actual YNAB API token and paste the contents in the new file
```
{
  "AppSettings": {
    "YnabApi": {
      "DevToken": "YOUR_YNAB_TOKEN_HERE"
    }
  }
} 
```
5. Close and rerun the application to use the new token.
