## Setup Instructions

### Configure Secrets

1. Get your YNAB token by following the instructions here: https://api.ynab.com/#personal-access-tokens
2. Create a file `appsettings.secrets.json` in YnabApp.Forms Project.
3. Set the "Copy to Output Directory" property of the new file to "Copy if newer" so that it is copied to the output directory when you build the project.
4. Replace `YOUR_YNAB_TOKEN_HERE` with your actual YNAB API token and paste the contents in the new file
```
{
  "AppSettings": {
    "YnabApi": {
      "DevToken": "YOUR_YNAB_TOKEN_HERE"
    }
  }
}
```
5. The `appsettings.secrets.json` file is gitignored and will not be committed

**Never commit your actual API tokens!**