<template>
    <d-container class='action'>
        <d-row justify='center'>
            <div class='form-group'>

                <d-input id="Login" class="mb-2 mr-sm-2 mb-sm-0" v-model="inputLogin" placeholder="Login" required />
            </div>

            <div class='form-group'>
                <d-form-input id="PasswordInput" type="password" v-model="inputPassword" required placeholder="Password"></d-form-input>
            </div>

            <div class='form-group'>
                <d-button pill theme='primary' @click='postLogin()'>Login</d-button>
            </div>
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
            postLogin() {
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
                        alert(error);
                    });
            }
        }
    };
</script>

<style>
    .action {
        display: flex;
        align-items: center;
        justify-content: center;
        height: 100vh;
    }
</style>