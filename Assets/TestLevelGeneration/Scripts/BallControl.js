#pragma strict

public var values : int[,];
public var prefabGround : GameObject;
public var prefabWall : GameObject;

function Start () {
		values = new int[3,20];
		
		for(var i : int = 0; i < 3; i++)
			for(var j : int = 0; j < 20; j++){
				values[i,j] = Random.Range(0, 3);
				if(values[i,j] == 0){
					//cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					//cube.transform.position = Vector3(Random.Range(-25, 26), Random.Range(0, 30), 0);
					Instantiate (prefabGround, Vector3(Random.Range(-25, 26), (i+0.3)*10, 0), Quaternion.identity);
				}
				if(values[i,j] == 2){
					//sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					//sphere.transform.position = Vector3(Random.Range(-25, 26), Random.Range(0, 30), 0);
					Instantiate (prefabWall, Vector3(Random.Range(-25, 26), (i)*10, 0), Quaternion.identity);
				}
			}				
}


function Update () {
	//InputPC();
}
/*
function InputPC(){

	if(Input.GetKey("left"))
		rigidbody2D.AddForce(Vector3.left);
	else if(Input.GetKey("right"))
		rigidbody2D.AddForce(Vector3.right);
		
	if(Input.GetKey("up"))
		rigidbody2D.AddForce(Vector3.up);
	else if(Input.GetKey("down"))
		rigidbody2D.AddForce(Vector3.down);
}
*/
