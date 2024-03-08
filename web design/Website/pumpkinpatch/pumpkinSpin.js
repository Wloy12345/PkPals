// Import styles
import './styles.css'

// Import required libraries
import * as THREE from 'three';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';

// Create the scene
const scene = new THREE.Scene();

// Load the pumpkin model
const loader = new GLTFLoader();
let pumpkinModel; // Variable to store the pumpkin model

loader.load('pumpkin.glb', function(gltf) {
  pumpkinModel = gltf.scene;
  pumpkinModel.rotation.x += 0.5;
  pumpkinModel.rotation.y += 0.5;
  scene.add(pumpkinModel);
});

// Create the camera
let camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);

// Get all the canvases with the same ID
const canvases = document.querySelectorAll('#pumpkinSpin');

// Loop through each canvas
canvases.forEach((canvas) => {
  const parentDiv = canvas.parentElement;

  // Create the renderer
  const renderer = new THREE.WebGLRenderer({
    canvas: canvas,
    alpha: true,
  });
  renderer.setClearColor(0xffffff, 0); // Set clearColor to match the page background color

  // Initial resize and event listener for window resize
  resizeRendererToParentSize();
  window.addEventListener('resize', resizeRendererToParentSize);

  // Function to resize the renderer to match the parent div size
  function resizeRendererToParentSize() {
    const width = parentDiv.offsetWidth * 0.9; // fix sides of the canvas
    const height = parentDiv.offsetHeight * 0.9;
    renderer.setSize(width, height);
    camera.aspect = width / height;
    camera.updateProjectionMatrix();
  }

  // Set camera position
  camera.position.set(0, 0, 1.5);
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

    // Rotate and move the pumpkin
    if (pumpkinModel) {
      pumpkinModel.rotation.y += 0.003;
    }

    renderer.render(scene, camera);
  }

  // Start the animation loop
  animate();
});