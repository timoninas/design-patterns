package abstract

type (
	Database interface {
		GetData(string) string
		PutData(string, string)
	}

	mongoDb struct {
		database map[string]string
	}

	mqlite struct {
		database map[string]string
	}
)

func (mdb *mongoDb) GetData(key string) string {
	return mdb.database[key]
}

func (mdb *mongoDb) PutData(key string, value string) {
	mdb.database[key] = value
}

type (
	File interface {
		GetFile(string) string
		CreateFile(string, string)
	}

	ntfs struct {
		system map[string]string
	}
)

func (fs *ntfs) GetFile(filename string) string {
	return fs.system[filename]
}

func (fs *ntfs) CreateFile(filename string, content string) {
	fs.system[filename] = content
}

func NewAbstractFactory(variety string) interface{} {
	switch variety {
	case "db":
		return &mongoDb{make(map[string]string)}

	case "fs":
		return &ntfs{make(map[string]string)}

	default:
		return nil
	}
}
