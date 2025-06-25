extends TileMapLayer


var rg: RoomGenerator = RoomGenerator.new()


func _ready() -> void:
	print(rg.seed)
	var room: Grid = rg.generate()
	
	for coords in room.cells:
		set_cell(coords - room.center, 0, Vector2i.ZERO)
