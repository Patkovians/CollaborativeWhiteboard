// Drawing Module
class Whiteboard {
    constructor(canvas) {
        this.canvas = canvas;
        this.context = canvas.getContext('2d');
        this.tools = {
            pencil: new PencilTool(this.context),
            eraser: new EraserTool(this.context),
            clearCanvas: new ClearCanvasTool(this.context)
        };
        this.currentTool = this.tools.pencil; // default to pencil
        this.bindEvents();
    }

    setTool(toolName) {

        if (this.tools[toolName]) {
            this.currentTool = this.tools[toolName];
            this.currentTool.setup(); // Set up the tool each time it's selected
        }
    }

    bindEvents() {
        this.canvas.addEventListener('mousedown', (e) => this.currentTool.handleMouseDown(e));
        this.canvas.addEventListener('mousemove', (e) => this.currentTool.handleMouseMove(e));
        this.canvas.addEventListener('mouseup', (e) => this.currentTool.handleMouseUp(e));
    }
    
    // ... methods for drawing, e.g., beginPath, movePath, endPath
}

// Tool Module
class Tool {
    constructor(context) {
        this.context = context;
        // ... shared tool properties like color, lineWidth
    }

    setup() {
        // Setup common to all tools; override in subclasses
    }
    
    handleMouseDown(e) {
        var mousePos = this.getMousePos(this.context.canvas, e);
        this.context.beginPath();
        this.context.moveTo(mousePos.x, mousePos.y);
        this.mouseDown = true;
    }

    handleMouseMove(e) {
        if (this.mouseDown) {
            var mousePos = this.getMousePos(this.context.canvas, e);
            this.context.lineTo(mousePos.x, mousePos.y);
            this.context.stroke();
        }
    }

    handleMouseUp(e) {
        this.mouseDown = false;
        this.context.closePath(); // Common behavior for all tools
    }

    // Adjust the offset relative to canvas
    getMousePos(canvas, evt) {
        var rect = canvas.getBoundingClientRect();
        return {
            x: evt.clientX - rect.left,
            y: evt.clientY - rect.top
        };
    }
}

class PencilTool extends Tool {
    constructor(context) {
        super(context);
        this.context.strokeStyle = "black"; // default pencil color
        this.context.lineWidth = 2; // default line width
    }

    setup() {
        this.context.globalCompositeOperation = 'source-over'; // normal drawing mode
        this.context.strokeStyle = 'black'; // default pencil color
        this.context.lineWidth = 5; // default line width
    }

    handleMouseDown(e) {
        super.handleMouseDown(e);
    }

    handleMouseMove(e) {
        super.handleMouseMove(e);
    }

    handleMouseUp(e) {
        super.handleMouseUp(e);
    }
}

class EraserTool extends Tool {
    constructor(context) {
        super(context);
        this.context.lineWidth = 20; // default eraser width
    }

    setup() {
        this.context.globalCompositeOperation = 'destination-out'; // erase mode
        this.context.strokeStyle = 'rgba(0,0,0,1)'; // required for destination-out to work
        this.context.lineWidth = 20; // default eraser width
    }

    handleMouseDown(e) {
        super.handleMouseDown(e);
    }

    handleMouseMove(e) {
        super.handleMouseMove(e);
    }

    handleMouseUp(e) {
        super.handleMouseUp(e);
    }
}

class ClearCanvasTool extends Tool {
    constructor(context) {
        super(context);
    }

    setup() {
        const canvas = document.getElementById('whiteboard-canvas');
        this.context.clearRect(0, 0, canvas.width, canvas.height);
        console.log("1 Cleared the canvas");
    }
}

// ... other tool classes

// UI Module
document.addEventListener('DOMContentLoaded', function() {
    const canvas = document.getElementById('whiteboard-canvas');
    let whiteboard = new Whiteboard(canvas);

    // Tool switch example
    document.getElementById('pen').addEventListener('click', () => whiteboard.setTool('pencil'));
    document.getElementById('eraser').addEventListener('click', () => whiteboard.setTool('eraser'));
    document.getElementById('clear-canvas').addEventListener('click', () => whiteboard.setTool('clearCanvas'));
    // Make sure the initial tool setup is called when the application starts
    whiteboard.currentTool.setup();
});
