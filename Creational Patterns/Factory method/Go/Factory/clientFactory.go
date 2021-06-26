package Factory

import (
	"log"
	"net/http"
)

type DoRequest interface {
	Do(req *http.Request) (*http.Response, error)
}

// MockHttpClient
type MockHTTPClient struct{}

func NewMockHTTPClient() DoRequest {
	return MockHTTPClient{}
}

func (c MockHTTPClient) Do(req *http.Request) (*http.Response, error) {
	return &http.Response{}, nil
}

// HttpClient
type SimpleHTTPClient struct{}

func NewSimpleHTTPClient() DoRequest {
	return SimpleHTTPClient{}
}

func (c SimpleHTTPClient) Do(req *http.Request) (*http.Response, error) {
	var client http.Client
	resp, err := client.Get("http://golang.org/")

	if err != nil {
		log.Println(err)
		return nil, err
	}

	log.Println(resp)
	return resp, nil
}
