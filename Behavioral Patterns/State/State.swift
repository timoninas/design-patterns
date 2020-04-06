// Pattern state
// Location tracker


// Класс Трекер с которым взаимодействует пользователь:
// переключает состояния. В данном классе лежит переменная state
// типа stateTracker
class Tracker {
    private lazy var state: stateTracker = EnabledState(tracker: self)
    var currentState: Bool {
        return state.currentState()
    }
    
    func startTracking() {
        state.startTracking()
    }
    
    func stopTracking() {
        state.stopTracking()
    }
    
    func pauseTracking() {
        state.pauseTracking()
    }
    
    func findPhone() {
        state.findPhone()
    }
    
    func setState(newState: stateTracker) {
        self.state = newState
    }
}

// stateTracker - протокол на который мы подписываем наши
// всевозможные состояния для нашего объекта.
// У трекера два состояния: вкл трекинг, выкл трекинг
protocol stateTracker {
    func startTracking()
    func stopTracking()
    func pauseTracking()
    func findPhone()
    func currentState() -> Bool
}

// Включенное состояние
class EnabledState: stateTracker {
    
    private var tracker: Tracker
    
    init(tracker: Tracker) {
        self.tracker = tracker
    }
    
    func startTracking() {
        print("Tracking location 1..")
        print("Tracking location 2..")
        print("Tracking location 3\n")
    }
    
    func stopTracking() {
        print("[Stop] current state - on")
        print("Change state now - off\n")
        
        tracker.setState(newState: DisabledState(tracker: tracker))
        tracker.stopTracking()
    }
    
    func pauseTracking() {
        print("[Pause] current state - on")
        print("Change state now - off\n")
        
        tracker.setState(newState: DisabledState(tracker: tracker))
        tracker.pauseTracking()
    }
    
    func findPhone() {
        print("[Find] current state - on")
        print("Phone is finded!\n")
    }
    
    func currentState() -> Bool {
        return true
    }
}

// Выключенное состояние
class DisabledState: stateTracker {
    
    private var tracker: Tracker
    
    init(tracker: Tracker) {
        self.tracker = tracker
    }
    
    func startTracking() {
        print("[Start] current state - off")
        print("Change state now - on\n")
        
        tracker.setState(newState: EnabledState(tracker: tracker))
        tracker.startTracking()
    }
    
    func stopTracking() {
        print("[Stop] nothing happend - off\n")
    }
    
    func pauseTracking() {
        print("[Pause] current state - off")
        print("Change state now - on\n")
        tracker.setState(newState: EnabledState(tracker: tracker))
        tracker.startTracking()
    }
    
    func findPhone() {
        print("[Find] current state - off")
        print("Change state now - on\n")
        
        tracker.setState(newState: EnabledState(tracker: tracker))
        tracker.findPhone()
    }
    
    func currentState() -> Bool {
        return false
    }
}

func board() {
    print("\n]--------------------------[\n")
}

func main() {
    
    let tracker = Tracker() // Initial state - Enabled (ON)
    
    tracker.startTracking() ; board()
    tracker.pauseTracking() ; board()
    tracker.stopTracking()  ; board()
    tracker.findPhone()     ; board()
    tracker.stopTracking()  ; board()
    tracker.stopTracking()  ; board()
}

main()
