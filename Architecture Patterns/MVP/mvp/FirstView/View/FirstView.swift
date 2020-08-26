import UIKit

class FirstView: UIViewController {
    var presenter: FirstPresenterOutput!
    var tableView: UITableView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        setupLayout()
        setupTableView()
    }
    
    func setupLayout() {
        self.view.backgroundColor = .white
    }
    
    func setupTableView() {
        tableView = UITableView()
        tableView.dataSource = self
        tableView.frame = self.view.frame
        tableView.register(UITableViewCell.self, forCellReuseIdentifier: "Cell")
        view.addSubview(tableView)
    }
}

extension FirstView: UITableViewDataSource {
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return presenter.posts?.count ?? 0
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: "Cell")
        let post = presenter.posts![indexPath.row]
        
        cell?.textLabel?.text = post.title
        cell?.detailTextLabel?.text = "\(post.userId)"
        return cell ?? UITableViewCell()
    }
}

extension FirstView: FirstPresenterInput {
    func success() {
        tableView.reloadData()
    }
    
    func failure(error: Error) {
        print(error.localizedDescription)
    }
}
