# Redemption Timer
This project lets you configure certain channel point rewards to create timers that will count down, and you can display these timers on your stream or wherever else you need them.

# AppSettings.json
```
{
  "Output": {
    "Redemptions": [
      {
        "Name": "Don't Swear",
        "Duration": "00:05:00",
        "SoundEffect": null,
        "UseMessage": false,
        "Enabled": true
      }
    ],
    "Filename": "output.txt"
  }
}
```
`Redemptions`

Each Redemption is made of:
- a `Name`, which must match your Channel Points reward,
- a `Duration`, which must be in the form of "hh:mm:ss", which is how much gets added to the relevant timer,
- a `SoundEffect`, which, if a valid sound file, will be played when the item is redeemed,
- `UseMessage` as true or false, indicating whether to use the redemption's user message as its own timer,
- `Enabled` as true or false, if false the redemption is ignored.

`Filename` is the filename that your data is output to, so that it can be displayed wherever you need it displayed.  Because this project constantly writes to the file, it is recommended you use something that constantly reads from the file (like BareTail or OBS display) rather than keeping the file open in a text editor (like Notepad).

# Connection.json
```
{
  "Twitch": {
    "ChannelName": "",
    "ChannelId": ""
    "OauthToken": ""
  }
}
```

This is the information required to connect to your channel and listen to events.
- `ChannelName` is your Twitch username.
- `ChannelId`, if you know it, means that the system doesn't have to look up your channel ID.  This parameter is optional.
- `OAuthToken` is the token that will let the application talk to Twitch on your behalf, to listen to the channel point redemptions.
