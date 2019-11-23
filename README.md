# VueNancy
using NancyFx with Vue.js

## Introduction
VueNancy is a solution for Visual studio, showing how you can create small web applications using C# and Vue.js

[NancyFX](https://github.com/NancyFx/Nancy) was selected as the backend framework, because it is a lightweight framework for building HTTP based services on .NET Framework/Core and Mono.
  
Well, [Vue.js](https://github.com/vuejs/vue) was chosen from personal preference, but you can use, for example, React, because there is also an axios library.
  
## Why was NancyFX chosen, not Asp.net?
Because Asp.net framework contains huge functionality that is not used in simple web applications and sites.
NancyFX implements REST Api, and this is enough

## Using
Let's write a simple application. The user sends a POST request with the text 'ping', and receives a 'pong' in response.

Vue.js (Frontend part)
```js
<template>
  <div class='form-group'>
    <button pill theme='primary' @click='sendPing()'>Send</button>
  </div>
</template>

<script>
import axios from 'axios';

export const HTTP = axios.create({
  //on port 8081 launched nancyfx
  baseURL: 'http://127.0.0.1:8081/api'
})

export default {
  methods: {
    sendPing(e) {
      HTTP
        .post('send-ping', {
          ping: 'ping'
        })
        .then(response => {
          if (response.data.success) {
            alert('pong');
          } else {
            alert('not pong :c');
          }
        })
    }
  }
};
</script>
```

On NancyFx (Backend part):
```csharp
Post("/login", args =>
{
  //Bind request data to class Ping
  var model = this.Bind<Ping>();
  
  //return success if request data is 'ping'
  return model.Ping == 'ping'
    ? Response.AsJson(new { success = true })
    : Response.AsJson(new { success = false });
});
```

It's simple!

## Interesting? Want to know more?
Welcome to [Wiki](https://github.com/kotC9/VueNancy/wiki)
