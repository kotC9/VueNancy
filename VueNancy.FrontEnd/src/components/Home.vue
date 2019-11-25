<template>
    <d-container class='dr-example-container'>
        <d-row>
            <d-col cols='12' md='4' lg='3'></d-col>
            <d-col cols='12' md='4' lg='6'>

                <div class='form-group'>
                    <label class="sr-only" for="Login">Login</label>
                    <d-input id="Login" class="mb-2 mr-sm-2 mb-sm-0" v-model="inputLogin" placeholder="Login" required />
                </div>

                <div class='form-group'>
                    <label for="PasswordInput" class="sr-only">Password</label>
                    <d-form-input id="PasswordInput" type="password" v-model="inputPassword" required placeholder="Password"></d-form-input>
                </div>

                <div class='form-group'>
                    <d-button pill theme='primary' @click='postLogin()'>Login</d-button>
                </div>
            </d-col>
            <d-col cols='12' md='4' lg='3'></d-col>
        </d-row>
    </d-container>
</template>

<script>
    import axios from 'axios';

    export const HTTP = axios.create({
        baseURL: 'http://127.0.0.1:8081/api'
    })

    export default {
        data() {
            return {
                inputLogin: '',
                inputPassword: ''
            };
        },
        methods: {
            postLogin(e) {
                HTTP
                    .post('login', {
                        login: this.inputLogin,
                        password: this.inputPassword
                    })
                    .then(response => {
                        if (response.data.success) {
                            alert('success');
                        } else {
                            alert('login or password wrong');
                        }
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        }
    };
</script>
