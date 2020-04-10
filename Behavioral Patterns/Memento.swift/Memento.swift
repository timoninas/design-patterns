import UIKit

struct Line {
    var start: CGPoint
    var end: CGPoint
    var color: UIColor
    
    init(start: CGPoint, end: CGPoint, color: UIColor) {
        self.start = start
        self.end = end
        self.color = color
    }
}

class Painter {
    private var lines: [Line] = []
    public var description: String {
        return lines.reduce("Points: ", { "\($0) \($1.start), \($1.end), \($1.color)\n" })
    }
    
    func draw(line: Line) {
        lines.append(line)
    }
    
    func getState() -> Memento {
        PainterMemento(lines: self.lines)
    }
    
    func setState(state: Memento) {
        self.lines = state.state
    }
}

protocol Memento {
    var state: [Line] { get }
}

final class PainterMemento: Memento {
    internal var state: [Line] = []
    
    init(lines: [Line]) {
        self.state = lines
    }
}

class Caretaker {
    var states: [Memento] = []
    var currentIndex: Int = 0
    var painter: Painter
    
    init(painter: Painter) {
        self.painter = painter
    }
    
    func save() {
        let tail = self.states.count - 1 - self.currentIndex
        if tail > 0 { states.removeLast(tail) }
        let state = painter.getState()
        states.append(state)
        print("Saved state: \(painter.description)\n")
    }
    
    func backToStateAt(steps: Int) {
        guard steps <= currentIndex else { return }
        
        currentIndex -= steps
        painter.setState(state: states[currentIndex])
        print("Back to state steps = \(steps): state: \(painter.description)\n")
    }
    
    func forwardToStateAt(steps: Int) {
        let index = currentIndex + steps
        guard index < states.count - 1 else { return }
        
        currentIndex = index
        painter.setState(state: states[currentIndex])
        print("Forward to state steps = \(steps): state: \(painter.description)\n")
    }
}

func main() {
    let painter = Painter()
    let caretaker = Caretaker(painter: painter)
    
    caretaker.save()
    
    painter.draw(line: Line(start: CGPoint(x: 2, y: 3), end: CGPoint(x: 10, y: -4), color: .black))
    painter.draw(line: Line(start: CGPoint(x: 5, y: 1), end: CGPoint(x: 5, y: -1), color: .brown))
    painter.draw(line: Line(start: CGPoint(x: 6, y: 2), end: CGPoint(x: 11, y: 1), color: .blue))
    painter.draw(line: Line(start: CGPoint(x: 8, y: 0), end: CGPoint(x: 13, y: -1), color: .brown))
    
    caretaker.save()
    
    painter.draw(line: Line(start: CGPoint(x: 6, y: 2), end: CGPoint(x: 11, y: 1), color: .blue))
    painter.draw(line: Line(start: CGPoint(x: 8, y: 0), end: CGPoint(x: 13, y: -1), color: .brown))
    
    caretaker.save()
}

main()
