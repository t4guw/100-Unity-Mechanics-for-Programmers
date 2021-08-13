# Tilemaps
## Description
This mechanic shows how to implement Tilemapping to your game

## Implementation
1. First you need a Tilemap PNG, you can think of it like minecraft blocks, there's a grass block, dirt block, stone block, etc, etc, all of these blocks can be contained and organized into one image (google tilemaps to see what I mean).
2. Import your Tilemap image to Unity, under it's settings within the inspector make sure it's set to Sprite 2D and UI.
3. Change the sprite mode to Multiple as this image contains multiple sprites.
4. Change the pixels per unit to match the size of your tiles in your tile map (in my case my tiles are 100x100 so I change this to 100)
5. Change the filter mode to Point as bilinear may cause your tiles to look blurry and disable Compression, make sure to hit Apply at the bottom.
6. The Sprite Editor should automatically pop up at this point, if not, you can manually bring it up by clicking the Window Tab, going down to 2D, and selecting Sprite Editor (and make sure you're editing your tilemap sprite).
7. In the Sprite Editor we're slicing up the Tilemap into it's tiles which you can have the editor do automatically by clicking Slice, changing Type to Grid By Cell Size (You could also do count) and make sure to set the Pixel Size to your tile sizes (100x100 in my case) and click Slice and Apply.
8. Now within your scene hierarchy create a Tilemap by navigating to 2D Object and Tilemap, in the Scene window you should see a grid now, you can adjust the grid size by selecting the grid object in the hierarchy.
9. Next bring up the Tile Palette window by going to the Window tab, 2D, Tile Palette. You will be relying on this window to "paint" your tiles onto the Scene so you may want to add this as a integrated window.
10. Create a New Palette and name it appropriately (If you want to separate your tiles on type, you could have a Water Palette, Ground Palette, and etc but it may be easier to just have one Palette for all of your tiles.
11. Unity will now ask for a folder to save your Palette to, just make sure it is within Assets and hit Select Folder.
12. Now you can drag your tiles from your tilemap (click the side arrow to make them expand out) onto the palette which will require each tile to become an asset which may warrant a separate folder within Assets for your tiles.
13. If you do your tiles one at a time you can name them, if you do multiple it will just ask for a folder to throw them into named after their tilemap name. Alternatively if you drag the parent tilemap, it will do the same thing as grouping but maintain the positions of the tiles like in the tilemap.
14. Now you can start painting your tiles onto your scene by clicking the brush in the tile palette and selecting the tile to use. The other tools are fairly self explanatory if you've ever used Paint.
15. If you want to do tiles ontop of tiles such as a farm house tileset over grass. you can create a new Tilemap object under the grid and set the Sorting Layer to higher than the grass Tilemap and make sure to change the Palette to the new tilemap.
16. If you want to have tiles to have colliders, simply go to the Tilemap object and add Tilemap Collider.