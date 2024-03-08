// Import styles
import './styles.css'

// Import required libraries
import * as THREE from 'three';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';

// Create the scene
const scene = new THREE.Scene();

// Load the pumpkin model
const loader = new GLTFLoader();
let pumpkinModels = []; // Array to store multiple pumpkin models
const pumpkinCount = 15; // Number of pumpkins to add

for (let i = 0; i < pumpkinCount; i++) {
  loader.load('pumpkin.glb', function(gltf) {
    const pumpkinModel = gltf.scene;
    pumpkinModel.rotation.x += 0.5;
    pumpkinModel.rotation.y += 0.5;
    pumpkinModel.scale.set(0.5, 0.5, 0.5); // Scale the pumpkin smaller
    pumpkinModels.push(pumpkinModel); // Add pumpkin model to the array
    scene.add(pumpkinModel);
  });
}

// Create the camera
let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

// Get the canvas and its parent div
const canvas = document.querySelector('#pumpkin');
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

  // Rotate and move the pumpkins
  for (let i = 0; i < pumpkinModels.length; i++) {
    const pumpkinModel = pumpkinModels[i];
    pumpkinModel.rotation.y += 0.025;
    pumpkinModel.rotation.x += 0.025;
    pumpkinModel.position.y -= Math.random() * 0.05; // Randomize fall speed

    // Randomize pumpkin position
    if (pumpkinModel.position.y < -15) {
      pumpkinModel.position.x = Math.random() * 10 - 5;
      pumpkinModel.position.y = Math.random() * (20 - 15) + 15; // Increase the range of y position
      pumpkinModel.position.z = Math.random() * 30 - 25;
      pumpkinModel.rotation.x = Math.random() * 2 * Math.PI;
    }
  }

  renderer.render(scene, camera);
}
// Start the animation loop
animate();
