Proyecto de Clase

> **Sugerencias**
> * Creen las cuentas [Github](https://github.com/) con sus correos institucionales
> * Verificar sus correos institucionales, por si Github les envia confirmación a sus correos
1. Verificar que si todo está bien uds deben tener acceso a un repositorio que se llama SoDisProyectoClase

---
## Para efectos de la nota de segundo corte

### 1. **Hacer Fork** del repositorio [https://github.com/wkrea/SoDisProyectoClase](https://github.com/wkrea/SoDisProyectoClase)
* Secuencia de pasos para crear el Fork
![Primeros pasos](./Docs/imgs/1.png)
* Esperar que se cree el fork
![Esperar que se cree elk fork](./Docs/imgs/2.png)
* verificar la correcta creación del fork
![](./Docs/imgs/3.png)

### clonar el repositorio bifurcado a su PC`

* Elija un lugar donde descargar los archivos del repositorio
* abra una terminal **GitBash** en esa ruta
![](./Docs/imgs/4.png)

* Ingrese el siguiente comando (*recuerde el ejemplo esta desarrollado con el usuario **malliwi88**, recuerde*)
```bash
git clone https://github.com/malliwi88/SoDisProyectoClase.git
```
![](./Docs/imgs/5.png)


Si todo va bien debería ver una carpeta `SoDisProyectoClase`

### 2. Desde el Fork **(de su repositorio)**, crear un branch **con el nombre de usuario de su correo institucional**

**Ejemplo**
Tomando como referencia al usuario `malliwi88@udi.edu.co`

* Abriendo la consola git Bash, **DENTRO DE la carpeta del repositorio bifurcado**
`SoDisProyectoClase`, haga uso del comando:
```bash
git checkout -b nombre_branch
```
![](./Docs/imgs/6.png)

el comando anterior debe haber creado un nuevo brach (**a nivel local**), con el nombre `nombre_branch`

## 3. Actualizar el fork (Mantenerse al día con el profe)

A medida que el profesor trabaja, los cambios se ven reflejados en el repositorio [wkrea/SoDisProyectoClase](https://github.com/wkrea/SoDisProyectoClase).

Pero **su FORK** (su repositorio --> [malliwi88/SoDisProyectoClase]()), puede no estar al día con los cambios realizados por profesor

Para poder tener al día su **bifuración**(fork), emplee los siquientes comandos

> ⚠ **Este paso solo se requiere la primera vez**
> ```bash
> git checkout master
> git remote add upstream https://github.com/wkrea/SoDisProyectoClase.git
> ```
> ![add upstream](./Docs/imgs/7.png)

Estos deben ser ejecutados cada vez que se quiera actualizar
```bash
git checkout master
git fetch upstream
git rebase upstream/master
git push -f origin master
```
> **CUANDO TODO ESTÁ AL DíA**
    > ![fetch upstream normal](./Docs/imgs/8.png)

> **CUANDO, EXISTÍAN ACTUALIZACIONES QUE NO TENIAS**
    > ![fetch upstream rebasing](./Docs/imgs/8.1png)


### Haciendo un Pull Request!!!

Ahora si todo esta bien, y **SU Repositorio FORK** está al día, debería estar en capacidad de enviar aportes al profesor, **es decir, eso que llaman pull request!!! o PRs**, vamos a por ello!!! 🤓
* haga `git checkout nombre_branch`` **recuerde cambiar por su usuario!!, malliwi88 es ejemplo**
* Actualice el archivo `control_avances.txt` ubicado en la **raiz del repositorio**, agregando su nombre de usuario Github (**ej: nombre_branch**) en el final del archivo, en una nueva linea.
* agregue los cambios a su branch, empleando `git add *`
* Haga el commit indicando como mensaje **nombre_branch modificó control_avances.txt**
* Haga `git push origin nombre_branch`
  > Esta imagen muestra la secuencia de pasos anterior, **tomando como ejemplo al usuario malliwi88**}
  > ![](./Docs/imgs/9.png) 


* Si todo va bien, debe ver los cambios en un nuevo branch en la pagina de su repositorio fork en [Github](https://github.com/)
    > ![](./Docs/imgs/10.png) 

* hacer la solicitud de cambios al profesor (**crear el PULL REQUEST**)
  > ![](./Docs/imgs/11.png)

* verificar que la solicitud quedo en proceso!!!
  > ![](Docs/imgs/12.png)


# Referencias
* [Actualizar el fork de un repositorio de GitHub](https://styde.net/actualizar-el-fork-de-un-repositorio-de-github/)
