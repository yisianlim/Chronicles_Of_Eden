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



## Reflection
### What I have learnt
### Most important 