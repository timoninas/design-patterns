import Foundation

protocol FirstPresenterInput {
    func success()
    func failure(error: Error)
}


