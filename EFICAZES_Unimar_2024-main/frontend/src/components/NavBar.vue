<template>
    <nav class="w-[auto] h-[95px] flex-shrink-0 flex items-center justify-between px-12 navbar__styles">
        <div class="flex items-center navbar__logo">
            <img src="../assets/images/logo.svg" alt="Logo" class="h-12 navbar__logo">
        </div>

        <!-- Menu normal -->
        <ul class="items__nav hidden lg:flex">
            <li class="items__menu"><a href="#" class="hover:text-blue-600">HOME</a></li>
            <li class="items__menu"><a href="#" class="hover:text-blue-600">SALE</a></li>
            <li class="items__menu"><a href="#" class="hover:text-blue-600">BUNDLE & SAVE</a></li>
            <li class="items__menu"><a href="#" class="hover:text-blue-600">SHOP BY CATEGORY</a></li>
            <li class="items__menu"><a href="#" class="hover:text-blue-600">SUPPORT</a></li>
        </ul>

        <div class="flex items-center space-x-4 items__nav__signin__signup hidden lg:flex">
            <!-- Mensagem de boas-vindas se o usuário estiver logado -->
            <span v-if="userLoggedIn" class="text-black font-semibold">Bem-vindo(a), {{ userName }}!</span>
            <a v-if="!userLoggedIn" href="/login" class="hover:text-blue-600 items__nav__sign">SIGN IN</a>
            <div class="text__sign__signup">&nbsp;</div>
            <a v-if="!userLoggedIn" href="/registration" class="text-white py-2 px-4 items__nav__signup">SIGN UP FOR FREE</a>
            <div v-if="userLoggedIn" class="flex items-center">
                <a href="/profile" id="btnPerfil" class="text-blue-800 hover:text-blue-600 items__nav__signup">Meu perfil&nbsp;&nbsp;</a>
                <div class="text__sign__signup">&nbsp;</div>
                <button @click="logout" class="text-red-600 hover:text-red-800">
                    &nbsp;&nbsp;
                    <span class="items__nav__logout text-red-600">LOG OUT</span>
                </button>
            </div>
        </div>

        <button @click="toggleDropdown" class="block lg:hidden">
            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24"
                stroke="currentColor" stroke-width="2">
                <path stroke-linecap="round" stroke-linejoin="round" d="M4 6h16M4 12h16M4 18h16" />
            </svg>
        </button>
    </nav>

    <div v-if="showDropdown" class="lg:hidden dropdown__menu">
        <ul class="dropdown__items">
            <li class="items"><a href="#" class="hover:text-blue-600">HOME</a></li>
            <li class="items"><a href="#" class="hover:text-blue-600">SALE</a></li>
            <li class="items"><a href="#" class="hover:text-blue-600">BUNDLE & SAVE</a></li>
            <li class="items"><a href="#" class="hover:text-blue-600">SHOP BY CATEGORY</a></li>
            <li class="items"><a href="#" class="hover:text-blue-600">SUPPORT</a></li>
            <li class="items" v-if="!userLoggedIn"><a href="/login" id="btnLogar" class="hover:text-blue-600">SIGN IN</a></li>
            <li class="items" v-if="!userLoggedIn"><a href="/registration" class="hover:text-blue-600">SIGN UP FOR FREE</a></li>
            <li class="items" v-if="userLoggedIn">
                <a href="/profile" class="text-blue-800 hover:text-blue-600">Meu perfil</a>
                <span class="text-blue-800 mx-2">|</span>
                <button @click="logout" class="text-red-600 hover:text-red-800">LOG OUT</button>
            </li>
            <li class="items" v-if="userLoggedIn">
                <span class="text-black font-semibold">Bem-vindo(a), {{ userName }}!</span>
            </li>
        </ul>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';

const showDropdown = ref(false);
const userLoggedIn = ref(false);
const userName = ref('');

function toggleDropdown() {
    showDropdown.value = !showDropdown.value;
}

// Função para deslogar
function logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    userLoggedIn.value = false;
    userName.value = '';
}

onMounted(() => {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
        userName.value = user.apelido.replace(/\"/g, '');
        userLoggedIn.value = true;
    }
});
</script>

<style scoped>
.navbar__logo {
    margin-left: 9.1%;
}

.items__nav__signin__signup {
    margin-right: 9.1%;
}

.navbar__styles {
    border: 1px solid rgba(217, 217, 227, 0.60);
    background: #FFF;
}

.navbar__logo {
    width: 135px;
    height: 26px;
    flex-shrink: 0;
    fill: #000;
}

.items__nav {
    display: inline-flex;
    padding: 0px 8px;
    justify-content: center;
    align-items: center;
    gap: 32px;
}

.items__menu {
    display: flex;
    align-items: center;
    color: var(--Black-black-500, #000);
    text-align: center;
    font-family: 'Inter', sans-serif;
    font-size: 14px;
    font-style: normal;
    font-weight: 400;
    line-height: 24px;
    letter-spacing: -0.14px;
    text-transform: uppercase;
}

.items__nav__sign {
    color: var(--Black-black-500, #000);
    text-align: center;
    font-family: 'Inter', sans-serif;
    font-size: 14px;
    font-style: normal;
    font-weight: 600;
    line-height: 24px;
    letter-spacing: -0.14px;
    text-transform: uppercase;
}

.items__nav__signup {
    color: var(--Blue-blue-500, #6987CD);
    text-align: center;
    font-family: 'Inter', sans-serif;
    font-size: 14px;
    font-style: normal;
    font-weight: 600;
    line-height: 24px;
    letter-spacing: -0.14px;
    text-transform: uppercase;
}

.items__nav__logout {
    text-align: center;
    font-family: 'Inter', sans-serif;
    font-size: 14px;
    font-style: normal;
    font-weight: 600;
    line-height: 24px;
    letter-spacing: -0.14px;
    text-transform: uppercase;
}
.dropdown__menu {
    background-color: #FFF;
    border: 1px solid rgba(217, 217, 227, 0.60);
    padding: 16px;
    transition: 3s ease-out;
}

.dropdown__items {
    display: flex;
    flex-direction: column;
    gap: 16px;
}

.text__sign__signup {
    background: #E6E6E6;
    width: 1px;
    height: 20px;
}

/* Ajustes de responsividade */
@media only screen and (max-width: 1024px) {
    .navbar__logo {
        margin-left: 0%;
    }
}

@media only screen and (max-width: 767px) {
    .navbar__logo {
        margin-left: 0%;
    }

    .items__menu {
        display: none;
    }
}

@media only screen and (min-width: 481px) and (max-width: 767px) {
    .items__menu {
        display: none;
    }
}

@media only screen and (min-width: 768px) and (max-width: 1024px) {
    .items__menu {
        display: none;
    }

    .dropdown__menu {
        width: 70%;
    }

    .navbar__styles {
        width: 70%;
    }
}

@media only screen and (min-width: 820px) and (max-width: 1180px) {
    .navbar__styles {
        width: 100%;
    }
}
</style>
