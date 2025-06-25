class_name AAA extends RefCounted



var val = 0




func _add(other: AAA) -> AAA:
	var new_a: AAA = AAA.new()
	new_a.val = self.val + other.val
	return new_a
