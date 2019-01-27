using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BookHolder : MonoBehaviour {

    private int _page = 0;

    public RectTransform BookUIRoot;
    public RectTransform LeftArrow;
    public RectTransform RightArrow;
    public RectTransform[] Pages;
    public UnityEvent PageTurned = new UnityEvent();

    public void OpenBook() => BookUIRoot.gameObject.SetActive(true);
    public void CloseBook() => BookUIRoot.gameObject.SetActive(false);
    public void TryNextPage() {
        if (_page < Pages.Length - 1) {
            turnPage(1);
            adjustArrows();
        }
    }
    public void TryPreviousPage() {
        if (_page > 0) {
            turnPage(-1);
            adjustArrows();
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void turnPage(int delta) {
        Pages[_page].gameObject.SetActive(false);
        _page += delta;
        Pages[_page].gameObject.SetActive(true);
        PageTurned.Invoke();
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void adjustArrows() {
        LeftArrow.gameObject.SetActive(_page > 0);
        RightArrow.gameObject.SetActive(_page < Pages.Length - 1);
    }

}
