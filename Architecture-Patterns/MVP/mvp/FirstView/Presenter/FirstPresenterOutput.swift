import Foundation

protocol FirstPresenterOutput {
    init(view: FirstPresenterInput, networkService: ProtocolNetworkService)
    var posts: [Post]? { get set }
    func getComments()
}
