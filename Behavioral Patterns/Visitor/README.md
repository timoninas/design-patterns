# Паттерн Посетитель

## Назначение

Паттерн Посетитель или Visitor описывает операцию, выполняемую с каждым объектом из некоторой структуры. 
Данный паттерн позволяет ввести/определить новую операцию, не изменяя классы объектов


## Демонстрация работы


![Visitor](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Visitor/Visitor.gif)


## Листинг 

#### Visitor.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Behavioral%20Patterns/Visitor/Visitor.swift)

```Swift
// Pattern Visitor
// Паттерн Посетитель
import UIKit

protocol Visitor {
    func visit(_ cell: FirstCell) -> CGFloat
    func visit(_ cell: SecondCell) -> CGFloat
    func visit(_ cell: ThirdCell) -> CGFloat
}


// MARK:- Pattern Visitor
class ConcreteVisitor: Visitor {
    func visit(_ cell: FirstCell) -> CGFloat {
        100
    }
    
    func visit(_ cell: SecondCell) -> CGFloat {
        80
    }
    
    func visit(_ cell: ThirdCell) -> CGFloat {
        return 60
    }

}

protocol Component {
    func accept(_ v: Visitor) -> CGFloat
}

class FirstCell: UITableViewCell {
}
class SecondCell: UITableViewCell {
}
class ThirdCell: UITableViewCell {
}

extension FirstCell: Component {
    func accept(_ v: Visitor) -> CGFloat {
        return v.visit(self)
    }
}

extension SecondCell: Component {
    func accept(_ v: Visitor) -> CGFloat {
        return v.visit(self)
    }
}

extension ThirdCell: Component {
    func accept(_ v: Visitor) -> CGFloat {
        return v.visit(self)
    }
}

class ViewController: UIViewController {

    @IBOutlet weak var tableView: UITableView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        tableView.delegate = self
        tableView.dataSource = self
        
        registerCells()
    }
    
    func registerCells() {
        tableView.register(FirstCell.self, forCellReuseIdentifier: "FirstCell")
        tableView.register(SecondCell.self, forCellReuseIdentifier: "SecondCell")
        tableView.register(ThirdCell.self, forCellReuseIdentifier: "ThirdCell")
    }
}

extension ViewController: UITableViewDelegate {
    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        let choice = indexPath.row % 3
        
        switch choice {
        case 0:
            return 60
        case 1:
            return 80
        case 2:
            return 100
        default:
            return 10
        }
    }
}

extension ViewController: UITableViewDataSource {
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        10
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let choice = indexPath.row % 3
        let cell: UITableViewCell?
        
        switch choice {
        case 0:
            cell = tableView.dequeueReusableCell(withIdentifier: "FirstCell")
            cell?.textLabel?.text = "It is First Cell"
        case 1:
            cell = SecondCell(style: .subtitle, reuseIdentifier: "SecondCell")
            cell?.textLabel?.text = "It is Second Cell"
            cell?.detailTextLabel?.text = "Details of this cell"
        case 2:
            cell = tableView.dequeueReusableCell(withIdentifier: "ThirdCell")
            cell?.imageView?.image = UIImage(named: "cell")
            cell?.textLabel?.text = "It is Third Cell"
        default:
            cell = UITableViewCell()
            cell?.textLabel?.text = "Default cell"
        }
        
        return cell!
    }
}
```
