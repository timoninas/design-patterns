
import Foundation
import UIKit

protocol Builder {
    func build() -> UIViewController
}

class CatalogBuilder: Builder {
    var title: String?
    var backgroundColor: UIColor?
    
    func setTitle(title: String) {
        self.title = title
    }
    
    func setColor(backgroundColor: UIColor) {
        self.backgroundColor = backgroundColor
    }
    
    func build() -> UIViewController {
        guard let color = backgroundColor else { fatalError("Цвет заднего фона не задан") }
        guard let title = title else { fatalError("Title не задан") }
        
        let presenter = CatalogPresenter()
        let interactor = CatalogInteractor(presenter: presenter)
        let view = CatalogViewController(title: title, backgroundColor: color, interactor: interactor)
        presenter.viewController = view
        
        return view
    }
}

