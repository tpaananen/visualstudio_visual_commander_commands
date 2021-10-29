# Visual Studio 2019/2022 Visual Commander extension commands
Enhances how Visual Studio Go to search bar behaves when initiated using shortcut keys.

### Visual Commander
You can find the extension from https://marketplace.visualstudio.com/items?itemName=SergeyVlasov.VisualCommander
More information about the extension https://vlasovstudio.com/visual-commander/

## Setting the commands to work
Install the extension for Visual Studio 2019. The extension can be accessed from the Extension menu in VS. Go to commands and add a new command.

### Adding a new command
Copy selected command, save, compile and run to test it works. Lets say the command was saved in the first slot.

Go to keyboard shortcuts in options (`Tools -> Options -> Environment -> Keyboard`). Search for `VCmd.Command01` and set `Global` hotkey.
For GoToMember command you would want to set the context as `Text editor` instead of `Global`.

## Commands
### Searching anything from everywhere

This is the same as invoking `Edit -> Go to -> Go To All...`
Shortcut command is Edit.GoToAll that we are executing. The difference is that we always want to set the Current file as unselected.

### Searching members from current file

This is the same as invoking `Edit -> Go to -> Go To Member...`
Shorcut command is Edit.GoToMember that we are executing. The difference is that we also want to actually sync explorer with the current text editor file so that the search actually works properly.

### Searching recent files

This is the same as invoking `Edit -> Go to -> Go To Recent File...`
Same as search anything from everywhere except the command is Edit.GoToRecentFile which lists the recent files you have worked on.
