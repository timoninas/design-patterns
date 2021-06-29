import XCTest
import UIKit

@testable import mvp

class FakeView: UIViewController, HomePresenterInput {
    var presenter: HomePresenterOutput?
    var greeting: String?
    
    func setGreeting(greeting: String) {
        self.greeting = greeting
    }
}

class HomeViewTests: XCTestCase {

    override func setUpWithError() throws {
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }

    override func tearDownWithError() throws {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
    }

    func testExample() throws {
        // This is an example of a functional test case.
        // Use XCTAssert and related functions to verify your tests produce the correct results.
    }
    
    func testHomeViewPresenter() throws {
        
        let person = Person(name: "Bady", text: "Bo")
        let view = FakeView()
        let presenter = HomePresenter(view: view, person: person)
        view.presenter = presenter
        
        presenter.setGreeting()
        
        XCTAssertEqual("Bady\nBo", view.greeting)
    }

    func testPerformanceExample() throws {
        // This is an example of a performance test case.
        self.measure {
            for _ in 0...9999999 {
                
            }
        }
    }
}

