
import Foundation
import UIKit

protocol Interactor {
    init(presenter: CatalogPresenter)
}

class CatalogInteractor: Interactor {
    var presenter: Presenter
    
    required init(presenter: CatalogPresenter) {
        self.presenter = presenter
    }
    

}
