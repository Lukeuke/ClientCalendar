import React from 'react';

function TokenHelper() {
  return window.localStorage.getItem("jwt");
}

export default TokenHelper;