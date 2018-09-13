using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A decription of all the items that can be combined with each other and the items they create.
/// </summary>
public class CombinationScheme : ScriptableObject {

    [SerializeField] CombinationDescription[] combinations; //The lists of avaliable combinations in this scheme.

    [System.Serializable]
    public class CombinationDescription
    {
        [SerializeField] EquipableItem firstItem; //The first item in the combination.
        [SerializeField] EquipableItem secondItem; //The second item in the combination.
        [SerializeField] EquipableItem result; //The item resulting from the combination.

        /// <summary>
        /// Returns the pair of items being combined in this description.
        /// </summary>
        public EquipableItem[] Items { get {

                EquipableItem[] items = new EquipableItem[2];

                items[0] = firstItem;
                items[1] = secondItem;

                return items;

            }
        }

        public EquipableItem Result { get { return result; } }

    }

    /// <summary>
    /// Return the item that results in the combination of the two items based on the scheme, or throw an error if there is none.
    /// </summary>
    /// <param name="item1"></param>
    /// <param name="item2"></param>
    /// <returns></returns>
    public EquipableItem combineItems(EquipableItem item1, EquipableItem item2)
    {

        foreach(CombinationDescription combination in combinations)
        {
            if (combination.Items[0] == item1 && combination.Items[1] == item2 ||
                combination.Items[0] == item2 && combination.Items[1] == item1) return combination.Result;
        }

        throw new InvalidCombinationException(item1, item2);

    }

    /// <summary>
    /// Returns all the items the given item can be combined with in the current scheme.
    /// </summary>
    /// <param name="item1"></param>
    /// <returns></returns>
    public EquipableItem[] eligibleItemsToCombineWith(EquipableItem item1)
    {

        List<EquipableItem> eligibleItems = new List<EquipableItem>();

        foreach(CombinationDescription combination in combinations)
        {

            EquipableItem[] items = combination.Items;

            if (items[0] == item1) eligibleItems.Add(items[1]);
            else if (items[1] == item1) eligibleItems.Add(items[0]);

        }

        return eligibleItems.ToArray();

    }

    /// <summary>
    /// Thrown when two items that do not have a combination in the scheme are combined.
    /// </summary>
    public class InvalidCombinationException : System.Exception
    {

        public InvalidCombinationException(EquipableItem item1, EquipableItem item2) :
            base("The items " + item1.name + " and " + item2.name + " do not have a combination in this scheme.")
        {

        }

    }

}
