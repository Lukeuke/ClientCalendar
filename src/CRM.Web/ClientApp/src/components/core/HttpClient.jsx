import React from 'react';

class HttpClient {

  baseUrl = "api/";
  #fullUrl = this.baseUrl;
  
  constructor(url) {
    this.#fullUrl = this.baseUrl + url;
  }
  
  
}

export default HttpClient;