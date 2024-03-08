// Import styles
import './styles.css'

// Import required libraries
import * as THREE from 'three';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';

// Create the scene
const scene = new THREE.Scene();

// Load the tomato model
const loader = new GLTFLoader();
let tomatoModels = []; // Array to store multiple tomato models
const tomatoCount = 15; // Number of tomatoes to add

for (let i = 0; i < tomatoCount; i++) {
  loader.load('tomato.glb', function(gltf) {
    const tomatoModel = gltf.scene;
    tomatoModel.rotation.x += 0.5;
    tomatoModel.rotation.y += 0.5;
    tomatoModel.scale.set(0.5, 0.5, 0.5); // Scale the tomato smaller
    tomatoModels.push(tomatoModel); // Add tomato model to the array
    scene.add(tomatoModel);
  });
}

// Create the camera
let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

// Get the canvas and its parent div
const canvas = document.querySelector('#tomato');
const parentDiv = canvas.parentElement;

// Create the renderer
const renderer = new THREE.WebGLRenderer({
  canvas: canvas,
  alpha: true,
});
renderer.setClearColor(0xffffff, 0); // Set clearColor to match the page background color

// Function to resize the renderer to match the parent div size
function resizeRendererToParentSize() {
  const width = parentDiv.offsetWidth;
  const height = parentDiv.offsetHeight;
  renderer.setSize(width, height);
  camera.aspect = width / height;
  camera.updateProjectionMatrix();
}

// Initial resize and event listener for window resize
resizeRendererToParentSize();
window.addEventListener('resize', resizeRendererToParentSize);

// Set camera position
camera.position.set(0, -0.01, 3);
camera.lookAt(scene.position);

// Render the scene with the camera
renderer.render(scene, camera);

// Add lights to the scene
const pointLight = new THREE.PointLight(0xffffff, 150);
pointLight.position.set(10, 10, 10);
const ambientLight = new THREE.AmbientLight(0xffffff, 0.8);
scene.add(pointLight, ambientLight);

// Animation loop
function animate() {
  requestAnimationFrame(animate);

  // Rotate and move the tomatoes
  for (let i = 0; i < tomatoModels.length; i++) {
    const tomatoModel = tomatoModels[i];
    tomatoModel.rotation.y += 0.025;
    tomatoModel.rotation.x += 0.025;
    tomatoModel.position.y -= Math.random() * 0.05; // Randomize fall speed

    // Randomize tomato position
    if (tomatoModel.position.y < -15) {
      tomatoModel.position.x = Math.random() * 10 - 5;
      tomatoModel.position.y = Math.random() * (20 - 15) + 15; // Increase the range of y position
      tomatoModel.position.z = Math.random() * 30 - 25;
      tomatoModel.rotation.x = Math.random() * 2 * Math.PI;
    }
  }

  renderer.render(scene, camera);
}
// Start the animation loop
animate();
