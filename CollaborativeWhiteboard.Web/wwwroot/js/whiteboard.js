// Drawing Module
class Whiteboard {
    constructor(canvas, context) {
        this.canvas = canvas;
        this.context = context;
        this.currentTool = new PencilTool(this.context);
        // ... other properties like color, lineWidth
    }
    
    setTool(tool) {
        this.currentTool = tool;
    }
    
    // ... methods for drawing, e.g., beginPath, movePath, endPath
}

// Tool Module
class Tool {
    constructor(context) {
        this.context = context;
        // ... shared tool properties like color, lineWidth
    }
    
    handleMouseDown() {
        // Tool-specific logic for mouse down
    }

    handleMouseMove() {
        // Tool-specific logic for mouse move
    }

    handleMouseUp() {
        // Tool-specific logic for mouse up
    }

    // ... other shared methods and properties
}

class PencilTool extends Tool {
    constructor(context) {
        super(context);
        this.context.strokeStyle = '#ffffff'; // default pencil color
        this.context.lineWidth = 2; // default line width
    }

    handleMouseDown(e) {
        this.context.beginPath();
        this.context.moveTo(e.offsetX, e.offsetY);
        console.log("Location (x,y):  " + "(" + e.offsetX + ", " + e.offsetY + ")");
    }

    handleMouseMove(e) {
        if (this.mouseDown) {
            this.context.lineTo(e.offsetX, e.offsetY);
            this.context.stroke();
        }
    }

    handleMouseUp(e) {
        this.context.closePath();
        this.mouseDown = false;
    }
}

class EraserTool extends Tool {
    constructor(context) {
        super(context);
        this.context.globalCompositeOperation = 'destination-out'; // erase mode
        this.context.lineWidth = 5; // default eraser width
    }

    handleMouseDown(e) {
        this.context.beginPath();
        this.context.moveTo(e.offsetX, e.offsetY);
        this.mouseDown = true;
        console.log("Location (x,y):  " + "(" + e.offsetX + ", " + e.offsetY + ")");

    }

    handleMouseMove(e) {
        if (this.mouseDown) {
            this.context.lineTo(e.offsetX, e.offsetY);
            this.context.stroke();
        }
    }

    handleMouseUp(e) {
        this.context.closePath();
        this.mouseDown = false;
        this.context.globalCompositeOperation = 'source-over'; // reset to default mode
    }
}

// ... other tool classes

// UI Module
document.addEventListener('DOMContentLoaded', function() {
    const canvas = document.getElementById('whiteboard-canvas');
    const context = canvas.getContext('2d');
    let whiteboard = new Whiteboard(context, context);

    // Instantiate tools
    let pencil = new PencilTool(context);
    let eraser = new EraserTool(context);

    // Attach event listeners to canvas
    canvas.addEventListener('mousedown', (e) => {
        whiteboard.currentTool.handleMouseDown(e);
    });

    canvas.addEventListener('mousemove', (e) => {
        whiteboard.currentTool.handleMouseMove(e);
    });

    canvas.addEventListener('mouseup', (e) => {
        whiteboard.currentTool.handleMouseUp(e);
    });

    // Tool selection
    document.getElementById('pen').addEventListener('click', () => {
        whiteboard.setTool(pencil);
        console.log('Pencil tool selected');
    });

    document.getElementById('eraser').addEventListener('click', () => {
        whiteboard.setTool(eraser);
        console.log('Eraser tool selected');
    });


    // ... other UI controls
});
