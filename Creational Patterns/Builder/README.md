# Паттерн Строитель

## Назначение 

Паттерн Строитель или Builder предназначен для облегчения процесса сложной инициализации мы делаем настройку объекта в
паттерне Строитель. Builder - конструирует сложный объект

## Различие Builder с Abstract Factory

Различие паттерна строитель с паттерном абстрактная фабрика в том, что
строитель поэтапно конструирует объект, в то время как паттерн абстрактная фабрика
создает семейство объектов: простых или сложных

## Листинг 

#### Builder.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Builder/Builder.swift)

```Swift
import Foundation
import UIKit

protocol Builder {
    func build() -> UIViewController
}

class CatalogBuilder: Builder {
    private var title: String?
    private var backgroundColor: UIColor?
    
    // Установка заголовка для ViewController
    func setTitle(title: String) { 
        self.title = title
    }
    
    // Установка цвета ViewController
    func setColor(backgroundColor: UIColor) {
        self.backgroundColor = backgroundColor
    }
    
    func build() -> UIViewController {
    
        // Если цвет или заголовок не установлены, тогда ошибка
        guard let color = backgroundColor else { fatalError("Цвет заднего фона не задан") }
        guard let title = title else { fatalError("Title не задан") }
        
        // Подготовка по архитектуре YARCH для презентации ViewController
        let presenter = CatalogPresenter()
        let interactor = CatalogInteractor(presenter: presenter)
        let view = CatalogViewController(title: title, backgroundColor: color, interactor: interactor)
        presenter.viewController = view
        
        // Возвращаем готовый для выпуска ViewController
        return view
    }
}
```

## Архитектура Альфа банка - YARCH 

<p align="center">
  <img src="https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Builder/yarch.png"/>
</p>

## Листинг YARCH

#### CatalogViewController.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Builder/CatalogViewController.swift)

```Swift
class CatalogViewController: UIViewController {
    let interactor: Interactor!
    
    init(title: String, backgroundColor: UIColor, interactor: Interactor) {
        self.interactor = interactor
        super.init(nibName: nil, bundle: nil)
        self.title = title
        self.view.backgroundColor = backgroundColor
    }
    
    required init?(coder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()

        self.view.backgroundColor = .green
    }
}
```

#### CatalogInteractor.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Builder/CatalogInteractor.swift)

```Swift
protocol Interactor {
    init(presenter: CatalogPresenter)
}

class CatalogInteractor: Interactor {
    var presenter: Presenter
    
    required init(presenter: CatalogPresenter) {
        self.presenter = presenter
    }
}
```

#### CatalogPresenter.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Builder/CatalogPresenter.swift)

```Swift
protocol Presenter {
    var messageInfo: String {get}
}

class CatalogPresenter: Presenter {
    weak var viewController: CatalogViewController?
    
    var messageInfo = "Create VC for present"
}
```
