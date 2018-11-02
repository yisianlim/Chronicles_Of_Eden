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
In the Inventory class, this is defined in the field:
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

#### Using IEnumerator

### Most Proud Of
#### Dialogue Systems



## Reflection
### What I have learnt
### Most important 