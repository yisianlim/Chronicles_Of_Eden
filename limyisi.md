# Yi Sian Lim
**Username:** limyisi  
**Role:** Owl  
**Primary Responsibility:**  


## Code Discussion
### Parts worked On
* [Some] Player Controller & Animations (During early development stages) 
* [All] Area transitions 
* [All] Dialogue System with NPC 
* [All] Interactive Tutorial Dialogue 
* [Touched] Inventory logic (Just to subscribe to the addition and equipment of item events) 
* [All] Inventory UI 
* [All] HP Bar displaying player's health 
* [All] AP Bar displaying player's dodge limit 
* [All] Transition animations 
* [Most] Magnet item 
* [Most] Sound effect 
* [Touched] Switch and gate controllers

### Most Interesting Code
#### Inventory UI using EventArgs to subscribe to player actions
I used C#'s existing EventArgs to update the inventory UI, which uses the Observer pattern. In the Inventory class, this is defined in the field:
```
public event EventHandler<InventoryEventArgs> ItemAdded;
```

When an item is added, the event is fired to notify its subscribers as shown.
InventoryEventArgs also stores the reference to the item that was picked up, which has the image of the 
respective item:
```
ItemAdded(this, new InventoryEventArgs(item));
```

Since the InventoryUI class needs to be notified when the item is added in order to update
the UI, it subscribes to the event as shown:
```
inventory.ItemAdded += InventoryUIItemAdded;
```

InventoryUIItemAdded is a method which updates the UI. It gets the image that is needed by simply calling 
e.item.Image.
```
private void InventoryUIItemAdded(object sender, InventoryEventArgs e) {
    // Updates the Inventory UI.
    image.sprite = e.item.Image;
}
```

The approach makes the code robust to new item or image changes. It also makes to more efficient as we only invoke the UI change once when there is a change in inventory. It is also separates the inventory logic from the UI which is conforms to the rules of Model-View-Controller.

#### Using IEnumerator
IEnumerator was used multiple times to wait for a couple of seconds before displaying certain UI components. However, the one that I found to be most interesting, was using it to type the dialogue sentences such that a character appears one at a time (instead of displaying the entire sentence at once). Doing that improves the look-and-feel of the dialogue box and overall gameplay.
```
IEnumerator TypeSentence(string sentence)
{
    dialogueText.text = "";
    foreach (char letter in sentence.ToCharArray())
    {
        dialogueText.text += letter;
        yield return null;
    }
}
```

### Most Proud Of
#### Dialogue Systems
The dialogue system implemented makes it easy to be reuse in parts of the code that needs to trigger the dialogue. There are 3 components for the dialogue system:
* Dialogue (Stores the sentences for the dialogue conversations)
* DialogueTrigger (Triggers the dialogue UI by calling DialogueManager with the Dialogue passed into it)
* DialogueManager (Invokes the dialogue UI with the Dialogue passed in by DialogueTrigger)

DialogueTrigger is added to the GameObject(s) that will trigger the dialogue, which will display the dialogue. This makes teh dialogue system to be rather robust in all sorts of situations. 


## Reflection
### What I have learnt
* Unity's IEnumerator is useful for a lot of things where an extra time is needed before something needs to happens. 
* Observer pattern is a very useful design pattern for doing things involving the UI. 
* Small weekly goals should be set each week so that there can be additional time for polish. 

### Most important 
* For such a large scale project, it is important to ensure that the communication between the team members are always clear. After a group discussion, it is always vital to record down our discussions so that everyone in the team member is not deprived of any crucial information. 
* Initially, there were a lot of things that I thought that I had to implement by myself, but later on, I found out that Unity have a lot of helpful built-in features that I could use instead. The lesson that I can take in from here is to do sufficient research before implementing a feature. 