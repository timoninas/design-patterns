# Паттерн Посредник

## Назначение

Паттерн Посредник или Mediator Инкапсулирует способ поведения множества объектов. Их взаимодействие
становится возможным только благодаря посреднику. Данный паттерн дает
большую гибкость системы, из-за того что она становится меньше зависеть от конкретных
объектов

## Листинг 

#### Mediator.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Mediator/Mediator.swift)

```Swift
// Pattern Mediator
// Паттерн Посредник
enum Action {
    case sensorActive
    case radarExecute
    case angleCount
    
}


// MARK:- Components
protocol Component {
    var mediator: Mediator? { get }
}

class Sensor: Component {
    var name: String
    var mediator: Mediator?
    
    init(name: String) {
        self.name = name
    }
    
    func activeSensor() {
        print("Sensor sended message for Radar")
        mediator?.notify(sender: self, action: .radarExecute)
    }
}

class Radar: Component {
    var name: String
    var mediator: Mediator?
    
    init(name: String) {
        self.name = name
    }
    
    func countAngle() {
        print("Radar sended message for Angle")
        mediator?.notify(sender: self, action: .angleCount)
    }
}

class Angle: Component {
    var name: String
    var mediator: Mediator?
    var angel: Int  = 0
    
    init(name: String) {
        self.name = name
    }
    
    func countAngle() {
        self.angel = Int(arc4random_uniform(10))
        if self.angel == 0 {
            print("Do not needed nothing")
        } else {
            print("Angle counted: \(self.angel)")
        }
    }
}


// MARK:- MEDIATOR
protocol MediatorProtocol {
    func notify(sender: Component, action: Action)
}

class Mediator: MediatorProtocol {
    private var sensor: Sensor
    private var radar: Radar
    private var angle: Angle
    
    init(sensor: Sensor, radar: Radar, angle: Angle) {
        self.sensor = sensor
        self.radar = radar
        self.angle = angle
    }
    
    func notify(sender: Component, action: Action) {
        switch action {
        case .sensorActive:
            sensor.activeSensor()
        case .radarExecute:
            radar.countAngle()
        case .angleCount:
            angle.countAngle()
        }
    }
    
    func goForward(steps: Int) {
        for value in 0..<steps {
            print("\nStep \(value)")
            sensor.activeSensor()
        }
    }
}

func main() {
    let sensor = Sensor(name: "Sensopr J10I2")
    let radar = Radar(name: "Radar KK")
    let angle = Angle(name: "Anglecius")
    
    let mediator = Mediator(sensor: sensor, radar: radar, angle: angle)
    
    sensor.mediator = mediator
    radar.mediator = mediator
    angle.mediator = mediator
    
    mediator.goForward(steps: 4)
    
}
```

## Output

```Console
Step 0
Sensor sended message for Radar
Radar sended message for Angle
Angle counted: 7

Step 1
Sensor sended message for Radar
Radar sended message for Angle
Do not needed nothing

Step 2
Sensor sended message for Radar
Radar sended message for Angle
Angle counted: 6

Step 3
Sensor sended message for Radar
Radar sended message for Angle
Do not needed nothing
```
