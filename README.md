# Visual Studio 2019 Visual Commander extension commands
Enhances how Visual Studio Go to search bar behaves when initiated using shortcut keys.

### Visual Commander
You can find the extension from https://marketplace.visualstudio.com/items?itemName=SergeyVlasov.VisualCommander
More information about the extension https://vlasovstudio.com/visual-commander/

## Searching anything from everywhere

This is the same as invoking Edit -> Go to -> Go to all...
Shortcut command is Edit.GoToAll that we are executing. The difference is that we always want to set the Current file as unselected.

## Searching members from current file

This is the same as invoking Edit -> Go to -> Go to member...
Shorcut command is Edit.GoToMember that we are executing. The difference is that we also want to actually sync explorer with the current text editor file so that the search actually works properly.

## Searching recent files

Same as search anything from everywhere except the command is Edit.GoToRecentFile which lists the recent files you have worked on.
