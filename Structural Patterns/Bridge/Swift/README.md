# Паттерн Мост 

## Назначение

Паттерн Мост или Bridge, Handle, Body отделяет абстракцию от реализации таким образом, 
что то и другое можно было изменять независимо

## Фотокарточка экрана

![Фотокарточка](https://github.com/timoninas/design-patterns/blob/master/Structural%20Patterns/Bridge/screen.png)

На фотокарточке представлен кастомный Day Picker. В Day Picker присутствует абстракция - DataSource, определяющая
сколько будет ячеек и что в них будет написано

## Листинг 

#### DayPicker.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Structural%20Patterns/Bridge/DayPicker.swift)

```Swift
protocol PickerDayDataSource {
    func pickerDayCount(in pickerDay: UIPickerDayView) -> Int
    func pickerDayTitle(pickerDay: UIPickerDayView, indexPath: IndexPath) -> String
}

class UIPickerDayView: UIControl {
    
    var buttons: [UIButton] = []
    var stackview: UIStackView = UIStackView()
    
    var dataSource: PickerDayDataSource? {
        didSet {
            setupView()
        }
    }
    
    func setupView() {
        let count = dataSource?.pickerDayCount(in: self)
        
        for index in 0..<count! {
            let button = UIButton(type: .system)
            let indexPath = IndexPath(row: index, section: 0)
            let title = dataSource?.pickerDayTitle(pickerDay: self, indexPath: indexPath)
            button.setTitle(title, for: .normal)
            button.setTitleColor(#colorLiteral(red: 0.5236918926, 
                                               green: 0.9591721892, 
                                               blue: 1, 
                                               alpha: 1), 
                                               for: .normal)
                                               
            button.setTitleColor(#colorLiteral(red: 0.2073595822, 
                                               green: 0.6023685336, 
                                               blue: 0.8753715158, 
                                               alpha: 1), 
                                               for: .normal)
            button.tag = index
            button.addTarget(self, action: #selector(selectedButton(sender:)), for: .touchUpInside)
            buttons.append(button)
        }
        
        stackview = UIStackView(arrangedSubviews: buttons)
        self.addSubview(stackview)
        
        stackview.spacing = 8
        stackview.axis = .horizontal
        stackview.alignment = .center
        stackview.distribution = .fillEqually
        stackview.frame = bounds
    }
    
    @objc func selectedButton(sender: UIButton) {
        print(#function)
        for index in 0..<buttons.count {
            buttons[index].isSelected = false
        }
        buttons[sender.tag].isSelected = true
    }
}
```

#### ViewController.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Structural%20Patterns/Bridge/ViewController.swift)

```Swift
class ViewController: UIViewController {

    let daysOfWeek = ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"]
    
    @IBOutlet weak var pickerDay: UIPickerDayView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        pickerDay.dataSource = self
    }
}

extension ViewController: PickerDayDataSource {
    func pickerDayCount(in pickerDay: UIPickerDayView) -> Int {
        daysOfWeek.count
    }
    
    func pickerDayTitle(pickerDay: UIPickerDayView, indexPath: IndexPath) -> String {
        daysOfWeek[indexPath.row]
    }
}
```
