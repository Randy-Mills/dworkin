# dworkin
Dworkin is a discord bot which can be called to randomly generate various useful things for Dungeon and Dragons.

![Dworkin](https://1.bp.blogspot.com/-0UhSMUJoc3Q/Xqs49eYugPI/AAAAAAAAAgo/qFC_xZzDX8Ee0wcvUkHnybpZrT6IaJkSQCLcBGAsYHQ/s320/wizard.gif)

To do:

Tables
- [x] New NPC names (using Namey by [muffinlabs](http://muffinlabs.com/))
- [ ] Clean up large _chaos_ wild magic table
- [ ] Add wondrous item tables
- [x] Add wild surge duration table
- [ ] More wild surge tables
- [ ] Update Madness table effects to include what is required to cure.

Behaviour/Architecture
- [ ] Better command structure
- [ ] Move tables to db (maybe dynamo) then setup tables on bot start
- [ ] Host bot on fly.io
- [x] Parse responses to automatically roll dice calls in strings. IE "You gain 1d3 wishes" would roll 1d3 and return the generated value in the string.
